using MomsCalculator.Models;
namespace MomsCalculator.service
{
    public class ItemService
    {
        public Item CreateItem(double price, string itemName)
        {
            Item item = new Item(price, itemName);
            return item;
        }
    }
}
