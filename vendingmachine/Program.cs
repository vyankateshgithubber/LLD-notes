using System;
using System.Collections.Generic;

namespace VendingMachineDesign
{
    // ==========================================
    // 1. DOMAIN MODELS (The "Things")
    // ==========================================
    
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; } // Price in cents/rupees

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }

    // Tracks item + quantity
    public class InventoryItem
    {
        public Product Product { get; private set; }
        public int Quantity { get; set; }

        public InventoryItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }

    // ==========================================
    // 2. THE STATE INTERFACE
    // ==========================================
    
    public interface IVendingMachineState
    {
        void InsertCoin(VendingMachine machine, int amount);
        void SelectProduct(VendingMachine machine, int code);
        void RefundFullMoney(VendingMachine machine);
        void DispenseProduct(VendingMachine machine, int code);
    }

    // ==========================================
    // 3. THE CONTEXT (The Vending Machine)
    // ==========================================
    
    public class VendingMachine
    {
        // State Management
        public IVendingMachineState CurrentState { get; private set; }
        
        // Data Management
        public int AmountCollected { get; set; }
        public Dictionary<int, InventoryItem> Inventory { get; private set; }

        public VendingMachine()
        {
            Inventory = new Dictionary<int, InventoryItem>();
            AmountCollected = 0;
            CurrentState = new IdleState(); // Initial State
        }

        // Setup method (Admin)
        public void AddProduct(int code, Product product, int quantity)
        {
            Inventory[code] = new InventoryItem(product, quantity);
        }

        // State Transition
        public void SetState(IVendingMachineState newState)
        {
            CurrentState = newState;
        }

        // --- Proxy Methods (User Actions) ---
        public void InsertCoin(int amount) => CurrentState.InsertCoin(this, amount);
        public void SelectProduct(int code) => CurrentState.SelectProduct(this, code);
        public void Refund() => CurrentState.RefundFullMoney(this);
        
        // Internal Trigger
        public void Dispense(int code) => CurrentState.DispenseProduct(this, code);
    }

    // ==========================================
    // 4. CONCRETE STATES
    // ==========================================

    // STATE 1: IDLE (Waiting for money)
    public class IdleState : IVendingMachineState
    {
        public void InsertCoin(VendingMachine machine, int amount)
        {
            Console.WriteLine($"[IDLE] Coin Inserted: {amount}");
            machine.AmountCollected += amount;
            machine.SetState(new HasMoneyState());
        }

        public void SelectProduct(VendingMachine machine, int code)
        {
            Console.WriteLine("[Error] Cannot select product. Insert money first.");
        }

        public void RefundFullMoney(VendingMachine machine)
        {
            Console.WriteLine("[Error] No money to refund.");
        }

        public void DispenseProduct(VendingMachine machine, int code)
        {
            Console.WriteLine("[Error] Invalid action.");
        }
    }

    // STATE 2: HAS MONEY (User can select or refund)
    public class HasMoneyState : IVendingMachineState
    {
        public void InsertCoin(VendingMachine machine, int amount)
        {
            Console.WriteLine($"[HAS MONEY] Coin Inserted: {amount}");
            machine.AmountCollected += amount;
        }

        public void SelectProduct(VendingMachine machine, int code)
        {
            // 1. Check if Code exists
            if (!machine.Inventory.ContainsKey(code))
            {
                Console.WriteLine("[Error] Invalid Product Code.");
                return;
            }

            var itemShelf = machine.Inventory[code];

            // 2. Check Stock
            if (itemShelf.Quantity <= 0)
            {
                Console.WriteLine("[Error] Item Out of Stock!");
                machine.Refund(); // Auto refund for convenience
                return;
            }

            // 3. Check Price
            if (machine.AmountCollected < itemShelf.Product.Price)
            {
                Console.WriteLine($"[Error] Insufficient Funds. Price: {itemShelf.Product.Price}, Paid: {machine.AmountCollected}");
                return;
            }

            // 4. Transition to Dispense
            Console.WriteLine($"[HAS MONEY] Product {itemShelf.Product.Name} selected. Processing...");
            machine.SetState(new DispenseState());
            
            // Auto-trigger dispense logic
            machine.Dispense(code);
        }

        public void RefundFullMoney(VendingMachine machine)
        {
            Console.WriteLine($"[REFUND] Returning full amount: {machine.AmountCollected}");
            machine.AmountCollected = 0;
            machine.SetState(new IdleState());
        }

        public void DispenseProduct(VendingMachine machine, int code)
        {
            Console.WriteLine("[Error] Select product first.");
        }
    }

    // STATE 3: DISPENSE (Internal processing)
    public class DispenseState : IVendingMachineState
    {
        // This is triggered automatically by the previous state
        public void DispenseProduct(VendingMachine machine, int code)
        {
            Console.WriteLine("[DISPENSING] Machine is creating output...");
            
            var itemShelf = machine.Inventory[code];

            // 1. Reduce Stock
            itemShelf.Quantity--;

            // 2. Calculate Change
            int change = machine.AmountCollected - itemShelf.Product.Price;
            machine.AmountCollected = 0; // Reset internal balance

            // 3. Output
            Console.WriteLine($"===========================================");
            Console.WriteLine($"   DISPENSED: {itemShelf.Product.Name}");
            if (change > 0)
            {
                Console.WriteLine($"   CHANGE RETURNED: {change}");
            }
            Console.WriteLine($"===========================================");

            // 4. Reset State
            machine.SetState(new IdleState());
        }

        // Block all user inputs while dispensing
        public void InsertCoin(VendingMachine m, int a) => Console.WriteLine("Wait! Dispensing...");
        public void SelectProduct(VendingMachine m, int c) => Console.WriteLine("Wait! Dispensing...");
        public void RefundFullMoney(VendingMachine m) => Console.WriteLine("Too late to refund.");
    }

    // ==========================================
    // 5. TEST SIMULATION (Main)
    // ==========================================
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- VENDING MACHINE SIMULATION ---\n");

            // 1. Setup Machine & Inventory
            VendingMachine vm = new VendingMachine();
            vm.AddProduct(101, new Product("Coke", 25), 5);   // Code 101, Price 25, Qty 5
            vm.AddProduct(102, new Product("Pepsi", 35), 2);  // Code 102, Price 35, Qty 2
            vm.AddProduct(103, new Product("Water", 10), 0);  // Code 103, Price 10, Qty 0 (Empty)

            // SCENARIO 1: Happy Path (Buy Coke)
            Console.WriteLine("--- Scenario 1: Success Buy ---");
            vm.InsertCoin(10);
            vm.InsertCoin(20); // Total 30
            vm.SelectProduct(101); // Price 25 -> Should get Item + 5 change

            Console.WriteLine("\n--- Scenario 2: Low Balance ---");
            vm.InsertCoin(10);
            vm.SelectProduct(102); // Price 35 -> Should fail

            Console.WriteLine("\n--- Scenario 3: Refund ---");
            vm.Refund(); // Get the 10 back

            Console.WriteLine("\n--- Scenario 4: Out of Stock ---");
            vm.InsertCoin(10);
            vm.SelectProduct(103); // Water is qty 0 -> Should fail & refund

            Console.ReadKey();
        }
    }
}