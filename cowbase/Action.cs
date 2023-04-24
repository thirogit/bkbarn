using System;
using System.Collections.Generic;
using System.Text;



namespace cowbase
{
    public class Action
    {
        
        private char m_cId;
        private string m_sAction;

        public static Action NEW = new Action('N', "NEW");
        public static Action UPDATE = new Action('U', "UPDATE");
        public static Action FRESH = new Action('F', "FRESH");
        public static Action SYNC = new Action('-', "SYNC");

        private Action(char cId,string sAction)
        {
            m_cId = cId;
            m_sAction = sAction;
        }

        public override string ToString()
        {
            return m_sAction;
        }

        public char GetId()
        {
            return m_cId;
        }

        public static Action FromCharacter(char cId)
        {
            switch (cId)
            {
                case 'N':
                    return NEW;
                case 'U':
                    return UPDATE;
                case 'F':
                    return FRESH;
                case '-':
                    return SYNC;
            }
            throw new SystemException("Illegal Action id");
        }
    }
}
