using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly Context _context;

    public OrderController(Context context)
    {
        _context = context;
    }

    // GET alles von api/Order
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
    {
        var orders = await _context.Orders.ToListAsync();

        if (orders == null || orders.Count == 0)
        {
            return NotFound();
        }
        return orders;
    }

    // GET by id von api/Order/id
    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<Order>> GetOrderById(int id)
    {
        var order = await _context.Orders.FindAsync(id);

        if (order == null)
        {
            return NotFound();
        }

        return order;
    }

    // POST nach api/Order
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<Order>> PostOrder(Order order)
    {
        order.CreateDate = DateTime.UtcNow;

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAllOrders), new { id = order.OrderID }, order);
    }

    // PUT nach api/Order/id
    [HttpPut("{id}")]
    [Authorize]
    public IActionResult PutOrder(int id, Order Order)
    {
        if (id != Order.OrderID)
        {
            return BadRequest();
        }
        _context.Entry(Order).State = EntityState.Modified;
        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OrderExists(id))
            {
                return NotFound();
            }
            else
                throw;
        }
        return NoContent();
    }

    private bool OrderExists(int id)
    {
        return _context.Orders.Any(e => e.OrderID == id);
    }

    // DELETE aus api/Order/id
    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult DeleteSOrder(int id)
    {
        var Order = _context.Orders.Find(id);
        if (Order == null)
        {
            return NotFound();
        }
        _context.Orders.Remove(Order);
        _context.SaveChanges();
        return NoContent();
    }
}
