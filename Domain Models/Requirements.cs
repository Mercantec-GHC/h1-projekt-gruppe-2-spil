using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Models
{
    public class Requirements
    {
        public int id;
        public string cpu;
        public string ram;
        public string os;
        public string gpu;
        public string diskStorage;
        public string directX;

        public void UpdateRequirements(string CPU, string RAM, string OS, string GPU, string storage, string DirectX)
        {
            cpu = CPU;
            ram = RAM;
            os = OS;
            gpu = GPU;
            diskStorage = storage;
            directX = DirectX;
        }
    }
}

