﻿using SpaceBank.Microservices.Rabbit.Domain.Core.Commands;

namespace SpaceBank.Microservices.Banking.Domain.Commands
{
    public abstract class TransferCommand : Command
    {
        public int From { get; protected set; }
        public int To { get; protected set; }
        public decimal Amount { get; protected set; }
    }
}
