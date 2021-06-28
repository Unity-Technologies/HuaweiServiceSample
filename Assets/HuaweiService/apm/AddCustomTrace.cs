using System;

namespace HuaweiService
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AddCustomTrace : Attribute
    {
        string m_name;
        bool m_enable;

        public AddCustomTrace(string name, bool enable = true){
            m_name = name;
            m_enable = enable;
        }

        public string name{
            get{
                return m_name;
            }
        }
        public bool enable{
            get{
                return m_enable;
            }
            set{
                m_enable = value;
            }
        }
    }
}
