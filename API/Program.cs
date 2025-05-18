using Microsoft.SemanticKernel;
using OpenAI;
using System.ClientModel;
using API.Hubs;
using API.Plugins;
using API.Services;
using API.ViewModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddKernel()
    .AddOpenAIChatCompletion(
        modelId: "google/gemini-2.5-flash-preview", 
        openAIClient: new OpenAIClient(
            credential: new ApiKeyCredential(
                "sk-or-v1-****e7f"),
            options: new OpenAIClientOptions
            {
                Endpoint = new Uri("https://openrouter.ai/api/v1")
            })
    ).Plugins.AddFromType<ProductPlugins>();


builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
        policy
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .SetIsOriginAllowed(origin => true)));



builder.Services.AddHttpClient();
builder.Services.AddSignalR();
builder.Services.AddSingleton<AIService>();

var app = builder.Build();
app.UseCors();

app.MapPost("/chat", async (AIService aiService, ChatRequestVM chatRequest, CancellationToken cancellationToken)
    => await aiService.GetMessageStreamAsync(chatRequest.Prompt, chatRequest.ConnectionId, cancellationToken));

app.MapHub<AIHub>("/ai-hub");

app.Run();