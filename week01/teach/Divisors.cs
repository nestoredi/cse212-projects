public static class Divisors {
    /// <summary>
    /// Entry point for the Divisors class
    /// </summary>
    public static void Run() {
        List<int> list = FindDivisors(80);
        Console.WriteLine("<List>{" + string.Join(", ", list) + "}"); // <List>{1, 2, 4, 5, 8, 10, 16, 20, 40}
        List<int> list1 = FindDivisors(79);
        Console.WriteLine("<List>{" + string.Join(", ", list1) + "}"); // <List>{1}
    }

    /// <summary>
    /// Create a list of all divisors for a number including 1
    /// and excluding the number itself. Modulo will be used
    /// to test divisibility.
    /// </summary>
    /// <param name="number">The number to find the divisor</param>
    /// <returns>List of divisors</returns>
    private static List<int> FindDivisors(int number) {
        List<int> results = new();
        
        // 1. Empezamos en 1 y corremos el bucle mientras 'i' sea menor que el número
        for (int i = 1; i < number; i++) {
            
            // 2. Si el residuo de dividir 'number' entre 'i' es 0, significa que es divisor
            if (number % i == 0) {
                
                // 3. Lo agregamos a la lista de resultados
                results.Add(i);
            }
        }
        
        return results;
    }
}