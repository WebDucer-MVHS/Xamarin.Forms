using Moq;
using Prism.Navigation;
using RezepteApp;
using RezepteApp.Models;
using RezepteApp.Services;
using RezepteApp.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System;

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

        [Fact]
        public void OnNavigetedTo_LoadFavoriteReceipts()
        {
            // Arrange
            var expected = new List<Receipt> {
                new Receipt{Title = "Test 1", IsFavorit = true},
                new Receipt{Title = "Test 2", IsFavorit = true}
            };
            var navService = Mock.Of<INavigationService>();
            var dataService = new Mock<IReceiptRepo>();
            dataService.Setup(s => s.GetFavoritesAsync())
                .ReturnsAsync(expected);

            var sut = new ReceiptListViewModel(dataService.Object, navService);

            // Act
            sut.OnNavigatedTo(null);

            // Assert
            dataService.Verify(v => v.GetFavoritesAsync(), Times.Once);
            //Assert.Equal(sut.ReceiptList, expected);
            sut.ReceiptList.Should().HaveCount(2);
            sut.ReceiptList.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Constructor_WhithNullRepo_ThrowsException()
        {
            // Arrange
            var navService = Mock.Of<INavigationService>();
            var dataRepo = (IReceiptRepo)null;

            // Act
            var sutAction = new Action(() => new ReceiptListViewModel(dataRepo, navService));

            // Assert
            sutAction.Should().ThrowExactly<ArgumentNullException>()
                .Which.ParamName.Should().Be("repo");
        }
    }
}
