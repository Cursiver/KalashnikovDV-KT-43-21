//using KalashnikovDV_KT_43_21.Models;

//namespace KalashnikovDV_KT_43_21.Tests
//{
//    public class TeacherTests
//    {
//        [Fact]
//        //false, ���� � ������������� ��� �������
//        public void Discipline_Null_False()
//        {
//            //�������� ������ Teacher � Degree = null.
//            var teacher = new Disciplines
//            {
//                DisciplineName = null,
//            };

//            var result = teacher.DisciplineName();

//            Assert.False(result);
//        }

//        [Fact]
//        //true, ���� � ������������� ���� �������.
//        public void HasDegree_Ktn_True()
//        {
//            var teacher = new Teacher
//            {
//                Degree = "�.�.�.",
//            };

//            var result = teacher.HasDegree();

//            Assert.True(result);
//        }

//        [Fact]
//        //false, ���� ������� ������������� ������� � �������� �������� (��������, � ��������� �����).
//        public void IsValidPotition_zavkaf_False()
//        {
//            var teacher = new Teacher
//            {
//                Position = "���. ���."
//            };

//            var result = teacher.IsValidPosition();

//            Assert.False(result);
//        }

//        [Fact]
//        public void IsValidPotition_Zavkaf_True()
//        {
//            var teacher = new Teacher
//            {
//                Position = "��. ��."
//            };

//            var result = teacher.IsValidPosition();

//            Assert.True(result);
//        }
//    }
//}