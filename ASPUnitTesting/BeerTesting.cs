using ASPTest.Controllers;
using ASPTest.Services;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace ASPUnitTesting;

public class BeerTesting
{
    private readonly BeerController _controller;
    private readonly IBeerServices _services;

    public BeerTesting()
    {
        _services = new BeerServices();
        _controller = new BeerController(_services);
    }
    
    [Fact]
    public void Get_Ok()
    {
        // Act
        var result = _controller.Get();

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void Get_Quantity()
    {
        // Act
        var result = (OkObjectResult)_controller.Get();
        
        // Assert
        var beers = Assert.IsType<List<Beer>>(result.Value);
        Assert.True(beers.Count > 0);
    }

    [Fact]
    public void GetById_Ok()
    {
        // Arrange
        int id = 1;
        
        // Act
        var result = _controller.GetById(id);
        
        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
    
    [Fact]
    public void GetById_Exists()
    {
        // Arrange
        int id = 1;
        
        // Act
        var result = (OkObjectResult)_controller.GetById(id);
        
        // Assert
        var beer = Assert.IsType<Beer>(result.Value);
        Assert.True(beer != null);
        Assert.Equal(beer.Id, id);
    }
    
    [Fact]
    public void GetById_NotFound()
    {
        // Arrange
        int id = 99;
        
        // Act
        var result = _controller.GetById(id);
        
        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
}