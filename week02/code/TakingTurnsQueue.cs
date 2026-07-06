/// <summary>
/// This queue is circular.  When people are added via AddPerson, then they are added to the 
/// back of the queue (per FIFO rules).  When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue.  Thus,
/// each person stays in the queue and is given turns.  When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given.  If the turns is 0 or
/// less than they will stay in the queue forever.  If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>
using System;
using System.Collections.Generic;

namespace week02
{
    /// <summary>
    /// Una cola que gestiona turnos de personas. Si a una persona le quedan turnos, 
    /// regresa al final de la fila después de ser atendida.
    /// </summary>
    public class TakingTurnsQueue
    {
        // Usamos una cola tradicional de C# (FIFO) para mantener el orden estricto de llegada
        private readonly Queue<Person> _people = new Queue<Person>();

        // Propiedad para obtener la cantidad actual de personas esperando
        public int Length => _people.Count;

        /// <summary>
        /// Añade una persona al final de la cola con un número inicial de turnos.
        /// </summary>
        public void AddPerson(string name, int turns)
        {
            var person = new Person(name, turns);
            _people.Enqueue(person); // FIFO: Entra por la parte de atrás de la cola
        }

        /// <summary>
        /// Obtiene a la siguiente persona en el frente, procesa su turno y decide 
        /// si debe regresar al final de la fila o salir de ella.
        /// </summary>
        public Person GetNextPerson()
        {
            // REQUISITO: Si no hay nadie en la cola, debe lanzar una excepción de operación inválida
            if (_people.Count == 0)
            {
                throw new InvalidOperationException("No hay nadie en la cola.");
            }

            // CORRECCIÓN DEL DEFECTO: Extraemos a la persona que está estrictamente al frente (Frente de la fila)
            Person person = _people.Dequeue();

            // Lógica de Turnos Finitos (valores mayores a 0)
            if (person.Turns > 0)
            {
                person.Turns--; // Consumimos el turno actual de la persona
                
                // Si tras el consumo todavía le quedan turnos pendientes, vuelve a formarse al final
                if (person.Turns > 0)
                {
                    _people.Enqueue(person);
                }
            }
            // CORRECCIÓN DEL DEFECTO (Turnos Infinitos): Si los turnos son 0 o negativos (ej. estilo "Forever")
            else
            {
                // Regresa automáticamente al final de la fila sin restar nada, manteniendo ciclos continuos
                _people.Enqueue(person);
            }

            return person;
        }

        // Sobrescribimos el método ToString para imprimir el estado actual de la cola en consola
        public override string ToString()
        {
            return string.Join(", ", _people);
        }
    }
}