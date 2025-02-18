
using Newtonsoft.Json;

namespace Backend.Models
{
    public class IngestModel
    {
        [JsonProperty("results")]
        public IngestUser[] Results {get; set;} = [];
        
    }
    
    public class IngestUser
    {
        [JsonProperty("gender")]
        public string Gender {get; set;} = string.Empty;
        [JsonProperty("name")]
        public IngestUserName Name {get; set;} = new();
        [JsonProperty("location")]
        public IngestUserLocation Location {get; set;} = new();
        [JsonProperty("email")]
        public string Email {get; set;} = string.Empty;
        [JsonProperty("login")]
        public IngestUserLogin Login {get; set;} = new();
        [JsonProperty("dob")]
        public IngestDate Date {get; set;} = new();
        [JsonProperty("registered")]
        public IngestDate Registered {get; set;} = new();
        [JsonProperty("cell")]
        public string? Cell {get; set;}
        [JsonProperty("phone")]
        public string? Phone {get; set;}
        [JsonProperty("id")]
        public IngestUserId Id {get; set;} = new();
        [JsonProperty("picture")]
        public IngestUserPicture? Picture {get; set;} = new();
        [JsonProperty("nat")]
        public string Nat {get; set;} = string.Empty;
       
    }
    
    public class IngestUserName 
    {
        [JsonProperty("title")]
        public string Title {get; set;} = string.Empty;
        [JsonProperty("first")]
        public string FirstName {get; set;} = string.Empty;
        [JsonProperty("last")]
        public string LastName {get; set;} = string.Empty;
    }
    public class IngestUserLocation
    {
        [JsonProperty("street")]
        public IngestUserStreet Street {get; set;} = new();
        [JsonProperty("city")]
        public string City {get; set;} = string.Empty;
        [JsonProperty("state")]
        public string State {get; set;} = string.Empty;
        [JsonProperty("country")]
        public string Country {get; set;} = string.Empty;
        [JsonProperty("postcode")]
        public string PostCode {get; set;} = string.Empty;
        [JsonProperty("coordinates")]
        public IngestUserCoordinates Coordinates {get; set;} = new();
        [JsonProperty("timezone")]
        public IngestUserTimezone Timezone {get; set;} = new();
       
    }
    public class IngestUserStreet
    {
        [JsonProperty("number")]
        public int Number;
        [JsonProperty("name")]
        public string Name {get; set;} = string.Empty;
    }
    public class IngestUserCoordinates
    {
        [JsonProperty("latitude")]
        public decimal Latitude;
        [JsonProperty("longitude")]
        public decimal Longitude;
    }
    public class IngestUserTimezone
    {
        [JsonProperty("offset")]
        public string Offset {get; set;} = string.Empty;
        [JsonProperty("description")]
        public string Description {get; set;} = string.Empty;
    }
    public class IngestUserLogin
    {
        [JsonProperty("uuid")]
        public string UUID {get; set;} = string.Empty;
        [JsonProperty("username")]
        public string UserName {get; set;} = string.Empty;
        [JsonProperty("password")]
        public string Password {get; set;} = string.Empty;
        [JsonProperty("salt")]
        public string Salt {get; set;} = string.Empty;
        [JsonProperty("md5")]
        public string MD5 {get; set;} = string.Empty;
        [JsonProperty("sha1")]
        public string SHA1 {get; set;} = string.Empty;
        [JsonProperty("sha256")]
        public string SHA256 {get; set;} = string.Empty;
    }
    public class IngestDate
    {
        [JsonProperty("date")]
        public DateTime Date;
        [JsonProperty("age")]
        public int Age;
    }
    public class IngestUserId
    {
        [JsonProperty("name")]
        public string Name {get; set;} = string.Empty;
        [JsonProperty("value")]
        public string Value {get; set;} = string.Empty;
    }
    public class IngestUserPicture
    {
        [JsonProperty("large")]
        public string Large {get; set;} = string.Empty;
        [JsonProperty("medium")]
        public string Medium {get; set;} = string.Empty;
        [JsonProperty("thumbnail")]
        public string Thumbnail {get; set;} = string.Empty;
    }
    
}