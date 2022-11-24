// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using rds_test.Data;

// namespace CaseTest;


// [TestClass]
// public class UnitTest1
// {
//     private readonly ApplicationContext _context;
//     public UnitTest1(ApplicationContext context)
//     {
//         context = _context;
//     }

//     [TestMethod]
//     public void GetUsersSuggestions()
//     {
//         //Arrange
//         var suggestion = (from s in _context.suggestion where s.title = "Få klær i garderobe" select s.case_num);
//         var expectedcase_num = 1;

//         //Assert
//         Assert.AreEqual(expectedcase_num, suggestion);

//     }
// }
