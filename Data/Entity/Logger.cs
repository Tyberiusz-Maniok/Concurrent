using Data.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


namespace Data
{
    public class Logger
    {
        private object _lock = new object();

        public void SaveLogsToFile(MovableEntity movableEntity)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var objectToSerialize = new
            {
                Timestamp = DateTime.Now,
                MovableEntity = movableEntity
            };

            string json = JsonSerializer.Serialize(objectToSerialize, jsonOptions);

            lock (_lock)
            {
                File.AppendAllText(Path.GetFullPath(@"..\..\..\..\logs.json"), json);
            }
        }
    }
}
