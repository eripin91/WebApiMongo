using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnWebApiMongo.Models
{
    public class Answer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nama { get; set; }
        public string Email { get; set; }
        public string NoHP { get; set; }
        public decimal JumlahPinjaman { get; set; }
        public string JangkaWaktu { get; set; }
        public string PekerjaanAnda { get; set; }
        public string LamaBekerja { get; set; }
        public string Jabatan { get; set; }
        public string LevelPengalaman { get; set; }
        public decimal PenghasilanBersih { get; set; }
        public string Provinsi { get; set; }
        public string Kota { get; set; }
        public string Kecamatan { get; set; }
        public string Kelurahan { get; set; }
        public string StatusPernikahan { get; set; }
        public string JumlahTanggungan { get; set; }
        public string PendidikanTerakhir { get; set; }
        public string StatusRumah { get; set; }
        public string KepemilikanKartuKredit { get; set; }
        public string JumlahKartuKredit { get; set; }
        public string TanggalLahir { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
