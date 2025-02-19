﻿using System.Text.Json.Serialization;
using EduSubscription.Infrastructure.Providers.Asaas.Serialization.Abstractions;
using Newtonsoft.Json;

namespace EduSubscription.Infrastructure.Providers.Asaas.Serialization.Dtos.Customers;

public record GetCustomersResponseDto : PaymentDto
{
    [JsonProperty("totalCount")] 
    public int TotalCount { get; set; } = 0;
    [JsonProperty("data")] 
    public List<CustomerDto> Customers { get; set; } = default!;
}

public record CustomerDto
{
    [JsonProperty("id")] 
    public string Id { get; set; } = string.Empty;
    [JsonProperty("name")] 
    public string Name { get; set; } = string.Empty;
}