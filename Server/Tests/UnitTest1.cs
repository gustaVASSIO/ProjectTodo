
using ProjectTodo.Models.Entities;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {

        [Fact]
        public void VerifyIfToObjectsAreEqual()
        {
            //Act
            Todo todoExpected = new Todo()
            {
                Name = "Teste todo object",
                DateConclusion = DateTime.Now
            };

            var todo = new Todo()
            {
                Name = todoExpected.Name,
                DateConclusion = todoExpected.DateConclusion
            };


            //Assert
            Assert.Equal(todoExpected, todo);

        }

    }
}