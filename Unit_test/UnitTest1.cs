using REST_API_TEST2;

namespace Unit_test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateTeacher_Name()
        {
            TeacherItem teacher = new TeacherItem("Никита","Чернов","Игоревич","1");
            string expect = "Никита";
            Assert.AreEqual(teacher.Name, expect);
        }
        [TestMethod]
        public void CreateTeacher_Surname()
        {
            TeacherItem teacher = new TeacherItem("Никита","Чернов","Игоревич","1");
            string expect = "Чернов";
            Assert.AreEqual(teacher.Surname, expect);
        }
        [TestMethod]
        public void CreateTeacher_MiddleName()
        {
            TeacherItem teacher = new TeacherItem("Никита","Чернов","Игоревич","1");
            string expect = "Игоревич";
            Assert.AreEqual(teacher.MiddleName, expect);
        }
        [TestMethod]
        public void CreateLocate_Auditorium()
        {
            LocateItem teacher = new LocateItem("1","402","4");
            string expect = "402";
            Assert.AreEqual(teacher.Auditorium, expect);
        }
        [TestMethod]
        public void CreateLocate_Building()
        {
            LocateItem teacher = new LocateItem("1","402","4");
            string expect = "4";
            Assert.AreEqual(teacher.Building, expect);
        }
        [TestMethod]
        public void CreateDate_Date()
        {
            DateStudyItem date = new DateStudyItem("2", "14.02.2023", "2023.02.14");
            string expect = "14.02.2023";
            Assert.AreEqual(date.Date, expect);
        }
        [TestMethod]
        public void CreateDate_PCDate()
        {
            DateStudyItem date = new DateStudyItem("2", "14.02.2023", "2023.02.14");
            string expect = "2023.02.14";
            Assert.AreEqual(date.Picker, expect);
        }

        [TestMethod]
        public void CreateEducProg()
        {
            EducationProgramItem date = new EducationProgramItem("2","История");
            string expect = "История";
            Assert.AreEqual(date.label, expect);
        }

    }
}