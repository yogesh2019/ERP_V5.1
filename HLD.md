# MiniERP - High-Level Design (HLD)

## 1. Overview
ERP for freelancers/small business - scalable, modular, using .NET 8 and Angular.

## 2. Architecture
- Hybrid Modular Monolith
- CQRS with MediatR
- Repository + UoW + Factory + Strategy + Specification + Mediator + Observer
- SOLID principles

## 3. Core Modules (initial)
- User Management
- Auth (JWT-based)
- Product / Service Catalog
- Invoicing

## 4. Tech Stack
- .NET 8 (API)
- Angular (Client)
- EF Core (SQL Server)
- MediatR, FluentValidation, AutoMapper

## 5. Project Structure
- MiniERP.API
- MiniERP.Application
- MiniERP.Domain
- MiniERP.Infrastructure

## 6. Future Enhancements
- Docker support
- CI/CD
- Logging & Monitoring
