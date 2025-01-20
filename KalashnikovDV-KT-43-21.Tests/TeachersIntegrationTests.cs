//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace KalashnikovDV_KT_43_21.Tests
//{
//    public readonly DbContextOptions<InstitutDbContext> _dbContextOptions;
//    internal class TeachersIntegrationTests
//    {
//        _dbContextOptions = new DbContextOptionsBuilder<InstitutDbContext>()
//        .UseInMemoryDatabase(databaseName: "discipline_db")
//        .Options;
//    }

//    [Fact]
//    public void IsValidDiciplineName_webProrgram_true()
//    {
//        //arrange
//        var testDiscipline = new DisciplineTests
//        {
//            DisciplineName = "Web-программирование"
//        };

//        //act
//        var result = testDiscipline.IsValidDiciplineName();

//        //assert
//        Assert.True(result);
//    }
//}
