using System;
using System.Collections.Generic;

/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // =========================================================================
        // Test 1
        // Scenario: Validar que no se puedan agregar más clientes si la cola está llena.
        // Se inicializa con capacidad de 1 y se intentan agregar 2 clientes.
        // Expected Result: El primer cliente se agrega con éxito. El segundo muestra mensaje de error.
        Console.WriteLine("Test 1: Probar límite de tamaño máximo (Cola Llena)");
        var testCs1 = new CustomerService(1);
        Console.WriteLine("-> Agregando primer cliente (Debe permitirlo):");
        testCs1.AddNewCustomer();
        Console.WriteLine("-> Intentando agregar segundo cliente (Debe mostrar error de límite):");
        testCs1.AddNewCustomer(); 

        // Defect(s) Found: El código original usaba '>' en lugar de '>=', lo que permitía 
        // ingresar un cliente extra por encima del límite máximo establecido.
        // =========================================================================

        Console.WriteLine("=================");

        // =========================================================================
        // Test 2
        // Scenario: Validar el correcto orden de atención (FIFO) y que no falle con 1 cliente.
        // Se agrega un cliente y se procede a atenderlo.
        // Expected Result: Debe mostrar correctamente los datos del cliente ingresado y removerlo.
        Console.WriteLine("Test 2: Probar flujo correcto de atención (ServeCustomer)");
        var testCs2 = new CustomerService(10);
        Console.WriteLine("-> Agregando un cliente para la prueba:");
        testCs2.AddNewCustomer();
        Console.WriteLine("-> Atendiendo al cliente (Debe mostrar sus datos correctamente):");
        testCs2.ServeCustomer();

        // Defect(s) Found: El código original ejecutaba 'RemoveAt(0)' antes de leer el elemento,
        // lo que borraba al cliente actual sin mostrarlo y causaba un error de índice fuera de rango.
        // =========================================================================

        Console.WriteLine("=================");

        // =========================================================================
        // Add more Test Cases As Needed Below
        // Test 3
        // Scenario: Intentar atender a un cliente cuando la lista está completamente vacía.
        // Expected Result: Debe mostrar un mensaje de error indicando que la cola está vacía.
        Console.WriteLine("Test 3: Probar atención en una cola vacía");
        var testCs3 = new CustomerService(5);
        testCs3.ServeCustomer();

        // Defect(s) Found: El código original no validaba si '_queue.Count == 0' antes de atender,
        // provocando una excepción de sistema al intentar remover elementos inexistentes.
        // =========================================================================
        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        // CAMBIO: Se cambiaron las propiedades a 'public' para que la clase externa 
        // CustomerService pueda leerlas en caso de ser necesario, o al menos mantener consistencia.
        public string Name { get; }
        public string AccountId { get; }
        public string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // CORRECCIÓN 1: Se cambió el operador '>' por '>=' 
        // Si el tamaño actual ya es igual al máximo, la cola ya está llena.
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Error: Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        // CORRECCIÓN 2: Validación defensiva. 
        // Si la cola está vacía, se muestra un mensaje de error amigable en lugar de romper el programa.
        if (_queue.Count == 0) {
            Console.WriteLine("Error: No customers in the queue to serve.");
            return;
        }

        // CORRECCIÓN 3: Se invirtió el orden lógico.
        // Primero obtenemos y guardamos los datos del cliente que está al frente (índice 0)...
        var customer = _queue[0];
        
        // ...luego lo removemos de la estructura...
        _queue.RemoveAt(0);
        
        // ...y finalmente mostramos la información en pantalla.
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}