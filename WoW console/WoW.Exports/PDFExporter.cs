using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.IO;
using WoW.Exports.Contracts;
using WoW_console;

namespace WoW.Exports
{
    public class PdfExporter: IPdfExporter
    {
        private IWoWDbContext dbContext;

        public PdfExporter(IWoWDbContext context)
        {
            this.dbContext = context;
        }

        public void CreatePDFReport(string path)
        {
            Directory.CreateDirectory(path);

            var filePath = path + "/Characters.pdf";
            using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Document doc = new Document();

                PdfWriter writer = PdfWriter.GetInstance(doc, stream);
                doc.Open();

                var columns = 6;
                var header = FontFactory.GetFont(FontFactory.TIMES_BOLD, 18);
                var normal = FontFactory.GetFont(FontFactory.TIMES, 12);
                var bold = FontFactory.GetFont(FontFactory.TIMES_BOLD, 12);

                var table = new PdfPTable(columns);
                PdfPCell cell = new PdfPCell(new Phrase("Characters report", header));
                cell.Colspan = 8;
                cell.HorizontalAlignment = 2;
                table.AddCell(cell);

                var tableHeaders = new List<string>() { "Name", "Player", "Race", "Class", "Faction", "Profession" };
                for (int i = 0; i < columns; i++)
                {
                    var headerCell = new PdfPCell(new Phrase(tableHeaders[i], bold));
                    headerCell.HorizontalAlignment = 1;
                    table.AddCell(headerCell);
                }

                var charactersWins = 0;
                var charactersLoses = 0;
                foreach (var character in this.dbContext.Characters)
                {
                    var characterName = new PdfPCell();
                    var characterPlayer = new PdfPCell();
                    var characterRace = new PdfPCell();
                    var characterClass = new PdfPCell();
                    var characterFaction = new PdfPCell();
                    var characterProfession = new PdfPCell();
                    //var characterLevel = new PdfPCell();
                    //var characterWins = new PdfPCell();
                    //var characterLoses = new PdfPCell();


                    var name = character.Name;
                    characterName.AddElement(new Phrase(name.ToString()));

                    var player =$"Player {character.Player.Username} in {character.Player.Servers} server";
                    characterPlayer.AddElement(new Phrase(player.ToString()));

                    var race = $"Race {character.Race.Name} located in {character.Race.Location}";
                    characterRace.AddElement(new Phrase(race.ToString()));

                    var heroClass = character.Class.Name;
                    characterClass.AddElement(new Phrase(heroClass.ToString()));

                    var faction = character.Faction.Name;
                    characterFaction.AddElement(new Phrase(faction.ToString()));

                    var profession = character.Profession.Name;
                    characterProfession.AddElement(new Phrase(profession.ToString()));

                    // level = character.Level;
                    //characterLevel.AddElement(new Phrase(level.ToString()));

                    // level = character.Wins;
                    //characterLevel.AddElement(new Phrase(level.ToString()));

                    // level = character.Loses;
                    //characterLevel.AddElement(new Phrase(level.ToString()));

                    table.AddCell(name);
                    table.AddCell(player);
                    table.AddCell(race);
                    table.AddCell(characterClass);
                    table.AddCell(faction);
                    table.AddCell(profession);
                    //table.AddCell(level);
                    //table.AddCell(wins);
                    //table.AddCell(loses);
                    //charactersWins += character.Wins;
                    //charactersLoses += character.Loses;

                }

                PdfPCell playerTotalWins = new PdfPCell();

                var phraseWins = new Phrase();
                phraseWins.Add(new Chunk("Total wins:", bold));
                phraseWins.Add(new Chunk($" {charactersWins} $", normal));
                playerTotalWins.AddElement(phraseWins);
                playerTotalWins.Colspan = 6;

                table.AddCell(playerTotalWins);

                PdfPCell playerTotalLoses = new PdfPCell();

                var phraseLoses = new Phrase();
                phraseLoses.Add(new Chunk("Total loses:", bold));
                phraseLoses.Add(new Chunk($" {charactersLoses} $", normal));
                playerTotalWins.AddElement(phraseLoses);
                playerTotalWins.Colspan = 6;

                table.AddCell(playerTotalLoses);

                doc.Add(table);
                doc.Close();
            }
        }
    }
}
