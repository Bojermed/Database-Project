﻿using Database;
using WoW_console;
using System;

namespace WoW.CreateCommands
{
    public class CreateNpcs
    {
        private readonly IWoWDbContext dbContext;

        public CreateNpcs(IWoWDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void GetNpcs(string name, string titles, int health, int genderId, int raceId, int classId, int factionId, int statusId, int zoneId)
        {
            var npcs = new Npcs()
            {
                Name = name,
                Titles=titles,
                Health=health,
                GenderId=genderId,
                RaceId=raceId,
                ClassId=classId,
                FactionId=factionId,
                StatusId=statusId,
                ZoneId=zoneId
            };

            this.dbContext.Npcs.Add(npcs);
        }
    }
}
