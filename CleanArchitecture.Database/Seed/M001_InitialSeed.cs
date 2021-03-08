using FluentMigrator;

namespace CleanArchitecture.Database.Seed
{
    public static class M001_InitialSeed
    {
        public static void SeedInitial(this Migration migration)
        {
            for (int i = 0; i < 5; i++)
            {
                migration.Insert.IntoTable("User").Row(new { Name = $"user{i}", Email = $"user{i}@email.com" });
            }
        }
    }
}
