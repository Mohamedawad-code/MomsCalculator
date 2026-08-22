namespace MomsCalculator.Models
{
    public class Item
    {
       public double Beforeprice { get; set; }
       public string ItemName { get; set; }
      
       public Item(double beforePrice, string itemName)
        {
            Beforeprice = beforePrice;
            ItemName = itemName;
        }


    }
}
