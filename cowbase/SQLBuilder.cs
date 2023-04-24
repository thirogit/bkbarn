using System;

namespace cowbase
{
	/// <summary>
	/// Summary description for SQLBuilder.
	/// </summary>
	public class SQLBuilder
	{
		public SQLBuilder()
		{
			
		}

		enum PFlag 
		{
			NONE = 0,
			NULL = 1,
			QUOTED = 2,
			GO = 4,
			SKIP = 8
				 
		}
		public static string GetSQLFlatDateStr(DateTime datetime)
		{
			
			return string.Format("{0:D4}{1:D2}{2:D2}",datetime.Year,datetime.Month,datetime.Day);
		}

		 public static string SQLSprintf(string fmt,params object[] args)
			{
				PFlag flags = PFlag.NONE;
				char quote = '\0';
								
				string result = String.Empty;
				for (int i = 0; i < fmt.Length; i++)
				{
					int n = 0, ix;
					for (ix = i; ix < fmt.Length && fmt[ix] != '%'; ix++) ;
					result += fmt.Substring(i, ix - i);
					if (ix >= fmt.Length) break;
					i = ix + 1;
				retry:
					switch (fmt[i]) 
					{
						case '0':
						case '1': case '2': case '3': case '4':
						case '5': case '6': case '7': case '8': case '9':
							n = 0;
							for (; i < fmt.Length && Char.IsDigit(fmt[i]); i++)
							{
								n = 10 * n + (int)Char.GetNumericValue(fmt[i]);
							}
							if (i == fmt.Length)
							{
								flags |= (PFlag.GO | PFlag.SKIP);
								goto default;
							}
							
							flags |= PFlag.GO;
							goto retry;
						case '\n':							
						case '\0':
							throw new ArgumentException("illegal format character");
						
						case '%':
							if((flags & PFlag.GO) == PFlag.GO)
							{
								flags |= PFlag.SKIP;
								i--;
								goto default;
							}
								
							result += '%';
							flags |= PFlag.GO;
							break;
						case 'q': 
						{
							//object val;
							//nextarg = getarg(args, nextarg, out val);
							
							//result = result.PadRight(result.Length + width);
							flags |= PFlag.QUOTED;
							quote = '\'';
							i++;
							if(i < fmt.Length)
								goto retry;
							else
								goto default;
							
						}
						case 'e':
						{
							flags |= PFlag.NULL | PFlag.QUOTED;
							quote = '\'';
							i++;
							if(i < fmt.Length)
								goto retry;
							else
								goto default;
						}
						case 'E':
						{
							flags |= PFlag.NULL | PFlag.QUOTED;
							quote = '"';
							i++;
							if(i < fmt.Length)
								goto retry;
							else
								goto default;
						}

						case 'n': 
						{
							flags |= PFlag.NULL;
							i++;

							if(i < fmt.Length)
								goto retry;
							else
								goto default;
						}
						case 'd':
							flags |= PFlag.QUOTED;
							quote = '"';
							i++;
							if(i < fmt.Length)
								goto retry;
							else
								goto default;

						default:
							if((flags & PFlag.GO) != PFlag.GO)
								new ArgumentException("malformed format string");
							else
							{
								
								if(n  >= args.Length)
									throw new ArgumentException("argument out of bounds");
								string argStr = EscapeSingleQuotes(args[n].ToString());
								
								if((flags & PFlag.NULL) == PFlag.NULL && argStr.Equals(""))
									result += "NULL";
								else
								{
									if((flags & PFlag.QUOTED) == PFlag.QUOTED)
										result += quote + argStr + quote;
									else
										result += args[n].ToString();
								}
								if((flags & PFlag.SKIP) != PFlag.SKIP)
									if(i < fmt.Length)
										result += fmt[i];
							}
							
								

							break;
					}
					flags = PFlag.NONE;
				}
				
				return result;
			}

         private static string EscapeSingleQuotes(string s)
         {
             return s.Replace("'", "''"); ;
         }

	}

   
}
