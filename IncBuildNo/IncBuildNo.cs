using System;
using System.IO;
using System.Diagnostics;
namespace IncBuildNo
{
    class IncBuildNo
    {
        [STAThread]
        static int Main(string[] args)
        {
            try
            {
                #region local variable definitions
                StreamReader file;
                string sLine;
                string sFile = "";
                string[] sTmp;
                int iPos = 0;
                #endregion
                #region get args[] and test if file exist
                if (args.Length < 1)
                {		//there must be the filename!
                    ErrHandler("Ussage: IncBuildNo [$Path\\]AssemblyInfo.cs [Release]", null);
                    return -2;
                }
                if (args.Length == 2) if (args[1] != "Release") return 0;//only 'Release' version increment (not Debug)
                if (!File.Exists(args[0]))
                {	//exists the file?
                    ErrHandler("File '" + args[0] + "' not found", null);
                    return -3;
                }
                #endregion
                #region open and read cs file
                try { file = new StreamReader(args[0], System.Text.Encoding.UTF7); }	//try to open the file
                catch (Exception Ex)
                {
                    ErrHandler("File '" + args[0] + "' not found\nException thrown: ", Ex);
                    return -4;
                }
                try
                {			//ge and read all lines
                    while ((sLine = file.ReadLine()) != null)
                    {
                        #region interpret version line
                        iPos = sLine.IndexOf("assembly: AssemblyVersion(");	//this line we want to change
                        if (iPos > 0)
                        {
                            sTmp = sLine.Split('.');							//get the text between '.' separated in an array
                            if (sTmp[sTmp.Length - 1] == "*\")]") sTmp[sTmp.Length - 1] = "0\")]";				//replace the '*' with '0'
                            int iTmp = int.Parse(sTmp[sTmp.Length - 1].Substring(0, sTmp[sTmp.Length - 1].Length - 3)) + 1; //increment the last number by 1
                            sTmp[sTmp.Length - 1] = iTmp.ToString();
                            sLine = "";
                            for (int i = 0; i < sTmp.Length; i++) sLine += sTmp[i] + ".";//concatenate the string again
                            sLine = sLine.Substring(0, sLine.Length - 1) + "\")]";
                        }
                        #endregion
                        sFile += sLine + "\n";			//collect the rest
                    }
                }
                catch (Exception ex)
                {
                    ErrHandler("(Reading File) Exception thrown: ", ex);
                    return -5;
                }
                file.Close();
                #endregion
                #region write cs file back
                try
                {
                    StreamWriter fileW = new StreamWriter(args[0], false, System.Text.Encoding.UTF8); //write the file back
                    fileW.Write(sFile.Substring(0, sFile.Length));
                    fileW.Close();
                    return 0;
                }
                catch (Exception Ex)
                {
                    ErrHandler("(Reading File) Exception thrown: ", Ex);
                    return -6;
                }
                #endregion
            }
            catch			// something else went wrong
            {
                return -10;
            }
        }
        static private void ErrHandler(string sError, Exception Ex)
        {
            try  //Write Error to Console and EventLog
            {
                TextWriter errorWriter = Console.Error;
                EventLog evlog = new EventLog("Application", Environment.MachineName, "BuildNoInc");
                errorWriter.WriteLine("(Reading File) Exception thrown: " + Ex);
                evlog.WriteEntry("(Reading File) Exception thrown: " + Ex.Message, EventLogEntryType.Error);
            }
            catch
            {
                //if EventLog is full etc.
            }
        }
    }
}