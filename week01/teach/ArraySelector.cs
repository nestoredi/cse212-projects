public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        // 1. Creamos el arreglo donde guardaremos el resultado final
        int[] result = new int[select.Length];

        // 2. Variables para recordar en qué posición vamos de cada lista
        int index1 = 0;
        int index2 = 0;

        // 3. Recorremos el arreglo selector
        for (int i = 0; i < select.Length; i++)
        {
            if (select[i] == 1)
            {
                // Si es 1, tomamos el elemento actual de list1 y avanzamos su índice
                result[i] = list1[index1];
                index1++;
            }
            else if (select[i] == 2)
            {
                // Si es 2, tomamos el elemento actual de list2 y avanzamos su índice
                result[i] = list2[index2];
                index2++;
            }
        }

        // 4. Devolvemos el arreglo final combinado
        return result;
    }
}