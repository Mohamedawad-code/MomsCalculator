using MomsCalculator.Models;
namespace MomsCalculator.service
{
    public class ItemService      
    {
        private List<Item> _items = new List<Item>();

        public Item CreateItem(double price, string itemName)
        {
            Item item = new Item(price, itemName);
            _items.Add(item);
            return item;
        }
    }
}
