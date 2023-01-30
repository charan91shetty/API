using Global.DataAccess.Data.enums;
using Global.DataAccess.Data.Table;
using Microsoft.EntityFrameworkCore;

namespace Global.DataAccess.Data
{
    public class DbInitializer
    {
        private ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            
            this.modelBuilder = modelBuilder;

        }
        public void Seed()
        {
            modelBuilder.Entity<Membership>().HasData(
                new Membership() {Id = 1,Title = "None", Type = MemberType.None },
                new Membership() {Id=2, Title = "VideoClub", Type = MemberType.Video_Club },
                new Membership() {Id=3, Title = "AudioClub", Type = MemberType.Audio_Club },
                new Membership() {Id=4, Title = "VideoAudioClub", Type = MemberType.Video_Audio_Club }
            );
           
        }
    }
}