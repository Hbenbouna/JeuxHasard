using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.PrimarySchool
{
    public class Teacher
    {
        internal Teacher()
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public School School { get { throw new NotImplementedException(); } }
        
        public Classroom Assignment
        {
            get { throw new ArgumentException(); }
        }

        public void AssignTo( Classroom c )
        {
            throw new ArgumentException();
        }
    }
}
