using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace week02
{
    [TestClass]
    public class PriorityQueueTests
    {
        [TestMethod]
        public void TestPriorityQueue_1()
        {
            // OBJETIVO: Verificar que el elemento con mayor prioridad sea removido primero (independientemente del orden de llegada).
            var priorityQueue = new PriorityQueue();

            // Insertamos datos mezclados: (Nombre del item, Nivel de prioridad)
            priorityQueue.Enqueue("ItemBajo", 2);
            priorityQueue.Enqueue("ItemCritico", 10); // Prioridad más alta
            priorityQueue.Enqueue("ItemMedio", 5);

            // CORRECCIÓN: Quitamos el Assert.Fail() viejo y ejecutamos la extracción
            var resultado = priorityQueue.Dequeue();

            // Verificación: El programa debe entregar obligatoriamente "ItemCritico" porque tiene prioridad 10
            Assert.AreEqual("ItemCritico", resultado, "Error: La cola no devolvió el elemento con la máxima prioridad.");
        }

        [TestMethod]
        public void TestPriorityQueue_2()
        {
            // OBJETIVO: Verificar el comportamiento FIFO de desempate cuando dos elementos tienen exactamente la misma prioridad.
            var priorityQueue = new PriorityQueue();

            // Ambos tienen prioridad 4, pero "PacientePrimero" llegó antes a la cola
            priorityQueue.Enqueue("PacientePrimero", 4);
            priorityQueue.Enqueue("PacienteSegundo", 4);

            var primerResultado = priorityQueue.Dequeue();

            // Verificación: Al empatar en prioridad, el algoritmo interno debe respetar la regla FIFO estándar
            Assert.AreEqual("PacientePrimero", primerResultado, "Error: No se respetó el orden FIFO al desempatar elementos con la misma prioridad.");
        }
    }
}