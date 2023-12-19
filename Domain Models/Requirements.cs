﻿using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
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



        public Requirements(string OS, string CPU, string RAM, string GPU, string storage, string DirectX)
    {
        os = OS;
        cpu = CPU;
        ram = RAM;
        gpu = GPU;
        diskStorage = storage;
        directX = DirectX;
    }

        public void UpdateRequirements(string CPU, string RAM, string OS, string GPU, string storage, string DirectX)
        {
            cpu = CPU;
            ram = RAM;
            os = OS;
            gpu = GPU;
            diskStorage = storage;
            directX = DirectX;

            string connectionString = System.Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING");
            using(SqlConnection _connection = new SqlConnection(connectionString)){
                 _connection.Open();
                string sqlcommnd = $"UPDATE dbo.GameRequirements SET os = @os, cpu = @cpu, ram = @ram, gpu = @gpu, storage = @diskStorage, directX = @directX WHERE ID = @newReviewId";
                using(SqlCommand command = new SqlCommand(sqlcommnd, _connection))
                {
                    command.Parameters.AddWithValue("@os", os);
                    command.Parameters.AddWithValue("@cpu", cpu);
                    command.Parameters.AddWithValue("@ram", ram);
                    command.Parameters.AddWithValue("@gpu", gpu);
                    command.Parameters.AddWithValue("@diskStorage", diskStorage);
                    command.Parameters.AddWithValue("@directX", directX);
                    command.ExecuteNonQuery();
                }
                _connection.Close();
            }

        }
    }
}

