using System;
using System.Collections.Generic;
using System.Text;

namespace BonchApp
{
    class Lesson
    {
        public int lesson_type { get; set; }
        public int lesson_number { get; set; }
        public string lesson_name { get; set; }
        public string teacher_name { get; set; }
        public string lecture_hall { get; set; }

        public Lesson(int number,string name, int type, string teachername, string hall)
        {
            this.lesson_number = number;
            this.lesson_name = name;
            this.teacher_name = teachername;
            this.lecture_hall = hall;
            this.lesson_type = type;

        }

        public Lesson()
        {

        }

        public string typeToString()
        {
            switch (lesson_type)
            {
                case 1:
                    return "лк";
                case 2:
                    return "пр";
                case 3:
                    return "лаб";
                default:
                    return "nan";
            }
        }

        public string getTime()
        {
            switch (lesson_number)
            {
                case 1:
                    return "9:00-10:35";
                case 2:
                    return "10:45-12:20";
                case 3:
                    return "13:00-14:35";
                case 4:
                    return "14:45-16:20";
                case 5:
                    return "16:30-18:05";
                default:
                    return "nan";
            }
        }

    }
}
