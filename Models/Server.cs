using System;

namespace coreangular.api.Models
{
    public class Server
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isOnline { get; set; }
    }
}