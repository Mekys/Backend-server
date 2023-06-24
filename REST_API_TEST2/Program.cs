using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using REST_API_TEST2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000", "http://localhost:3001",

                                              "http://www.contoso.com").AllowAnyHeader().AllowAnyMethod().AllowCredentials(); ; // add the allowed origins  
                      });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/*for (int group = 46; group <= 70; group++)
{
    for (int date = 428; date <= 433; date++)
    {
        for (int time = 53; time < 61; time++)
        {
            if (new Random().Next(11) <= 6)
            {
                int Locate = new Random().Next(28, 39);
                int teacher = new Random().Next(29, 38);
                int subject = new Random().Next(46, 57);

                string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
                MySqlConnection BDconnect = new MySqlConnection(connect);
                BDconnect.Open();
                var query = $"INSERT INTO `timetable`(`teacherId`, `subjectId`, `groupId`, `employeesId`, `dateId`, `timeId`, `locateId`) VALUES ('{teacher}','{subject}','{group}','{new Random().Next(1, 4)}','{date}','{time}','{Locate}')";
                MySqlCommand comand = new MySqlCommand(query, BDconnect);
                var reader = comand.ExecuteReader();
                reader.Close();
                BDconnect.Close();
            }
        }
    }
}*/


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(MyAllowSpecificOrigins);
app.Run();
