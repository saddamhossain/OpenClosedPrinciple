namespace OpenClosedPrinciple;


#region Open for Extension
/* Let's say we are working on an e-commerce application, and we have a requirement to calculate the total cost of an order with different types
 of discounts. We want to ensure that our code follows the Open-Closed Principle.

 The Discount class is the base class for calculating discounts. It's open for extension because we can easily create new types of discounts by
 creating subclasses without changing the existing Discount class.

 Subclasses like PercentageDiscount and FixedAmountDiscount extend the Discount class. These subclasses add new types of discounts
 without modifying the Discount class itself.
*/

// Open for Extension: This means we can add new functionality without changing the existing code.

// This is the base class for calculating discounts
public abstract class Discount
{
    public abstract double ApplyDiscount(double totalPrice);
}


// Now let's create concrete discount classes that extend the Discount class
public class NoDiscount : Discount
{
    public override double ApplyDiscount(double totalPrice)
    {
        return totalPrice; // No discount applied
    }
}

public class PercentageDiscount : Discount
{
    private double percentage;

    public PercentageDiscount(double percentage)
    {
        this.percentage = percentage;
    }

    public override double ApplyDiscount(double totalPrice)
    {
        return totalPrice - (totalPrice * percentage / 100); // Apply percentage discount
    }
}

public class FixedAmountDiscount : Discount
{
    private double amount;

    public FixedAmountDiscount(double amount)
    {
        this.amount = amount;
    }

    public override double ApplyDiscount(double totalPrice)
    {
        return totalPrice - amount; // Apply fixed amount discount
    }
}
#endregion


#region Closed for Modification
/* Closed for Modification: This means we don't need to change existing code when adding new functionality.
 The Order class represents an order in the e-commerce application. It has a list of discounts that are applied to the order's total price.

 The CalculateTotal method in the Order class calculates the total price of an order after applying all discounts. Notice that this method doesn't need
 to be modified when new types of discounts are added.

 When we want to introduce a new type of discount (e.g., a Buy One Get One Free discount), we can simply create a new subclass of the Discount class
 without changing the existing Order class or any of the other discount classes.

 Order class that uses the discount
*/
public class Order
{
    private List<Discount> discounts = new List<Discount>();

    public void AddDiscount(Discount discount)
    {
        discounts.Add(discount);
    }

    public double CalculateTotal(double basePrice)
    {
        double total = basePrice;

        foreach (var discount in discounts)
        {
            total = discount.ApplyDiscount(total);
        }

        return total;
    }
}
// This entire page of codebase follows the Open-Closed Principle because it enables us to extend the behavior of the system without altering its existing code.
#endregion