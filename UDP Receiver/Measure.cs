using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDP_Receiver {
    public class Measure {
        public string Classroom { get; set; }
        public double Temperature { get; set; }
        public int Humidity { get; set; }

        public Measure(string classroom, double temp, int hum) {
            Classroom = classroom;
            Temperature = temp;
            Humidity = hum;
        }

        public override string ToString() {
            return $"{Classroom} - {Temperature} - {Humidity}";
        }
    }
}
