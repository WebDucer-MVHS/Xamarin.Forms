using Moq;
using Prism.Navigation;
using RezepteApp;
using RezepteApp.Services;
using RezepteApp.ViewModels;
using System.Threading.Tasks;
using Xunit;

namespace RezeptApp.Tests
{
    public class ReceptListViewModelTests
    {
        [Fact]
        public void AddNewCommand_CallNavigation_ToMainPage()
        {
            // Arrange
            var dataService = Mock.Of<IReceiptRepo>();
            var navService = new Mock<INavigationService>();
            navService
                .Setup(s => s.NavigateAsync(nameof(MainPage)))
                .Returns(Task.CompletedTask);
            var sut = new ReceiptListViewModel(dataService, navService.Object);

            // Act
            sut.AddNewCommand.Execute();

            // Assert
            navService.Verify(s => s.NavigateAsync(nameof(MainPage)), Times.Once);
        }
    }
}
