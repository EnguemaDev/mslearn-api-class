using Pizza.Models;
using Pizza.Services;
using Microsoft.AspNetCore.Mvc;
namespace Pizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController: ControllerBase
{
    public PizzaController(){

    }

    [HttpGet]
    public ActionResult <List<Pizzas>> GetAll()=>
        PizzaServices.GetAll();
    

    [HttpGet("{id}")]
    public ActionResult<Pizzas> Get(int id){
        var pizza= PizzaServices.Get(id);
        if(pizza==null)
            return NotFound();
        return pizza;
    }

    [HttpPost]
    public IActionResult Create(Pizzas p){
        //This action will save a pizza and return a result
        PizzaServices.Add(p);
        return CreatedAtAction(nameof(Get), new { id = p.Id}, p);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizzas p){
        //This code will update the piza and retun de result
        if(id!=p.Id)
            return BadRequest();
        
        var existingPizza=PizzaServices.Get(id);
        if(existingPizza is null)
            return NotFound();

        PizzaServices.Update(p);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        //Ths code will delete the pizza and return a result
        var pizza = PizzaServices.Get(id);

        if(pizza is null)
            return NotFound();

        PizzaServices.Delete(id);
        
        return NoContent();

    }
    
}