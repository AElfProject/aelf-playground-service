using System;
using Volo.Abp.EventBus;

namespace AElf.Playground.Eto;

[EventName("AElf.Playground.Job.Response")]
public class JobResponseEto
{
    public Guid Id { get; set; }
    public required string Response { get; set; }
}