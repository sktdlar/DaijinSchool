using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaijinSchool.Models
{
    public partial class Courses
    {
        public string IsDeleted
        {
            get
            {
                if (App.db.DeletedCourses.Any(x => x.idCourse == id))
                {
                    return "Удален";
                }
                else
                {
                    return "Не удален";
                }
            }
        }
    }
}
