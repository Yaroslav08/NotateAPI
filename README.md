# Notate API

This is .NET client library for interactions with Notate api.

## Installation

> WARNING: This library is written in [.NET Standart 2.1](https://docs.microsoft.com/en-us/dotnet/standard/net-standard), therefore it supports the following platforms:
 * Xamarin Android 10+
 * Xamarin Mac 5.16+
 * Xamarin IOS 12+
 * Mono 6.4+
 * Windows 7+
 * Linux Ubuntu 17+
 * Lnux Debian 17+
 * Other platforms

 Not support in .NET Framework. [More](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)

## Basic Usage

### Register client

```csharp
NotateClient client = NotateClient.GetInstance(TypeUrl.Locale);
client.Register("Firstname","Lastname","Login","Password");
```

### Auth client

```csharp
client.Auth("Login", "Password");
```
### Get information about me
You can obtain user information in the following ways:

```csharp
User user = await client.LoadProfile();
```
or
```csharp
User user = await client.UserService.GetMe();
```
### Get user via ID
```csharp
User user = user.UserService.GetById(777);
```
### Get user via Username
```csharp
User user = user.UserService.GetByUsername("Some_Username");
```
### Create note
```csharp
await client.NoteService.Create(new CreateNoteModel 
{
    Header = "Some headers", 
    Text = "Some text", 
    IsPrivate = false, 
    Category = "Some tag", 
    IsHide = false, 
    DeadLine = DateTime.Now.AddDays(28) 
 });
```
### Get private note
```csharp
Note note = await client.NoteService.GetPrivate(1,"fae969c7-1b0e-4cfe-b0c1-d989e7e53716");
```
### Get comment notes
```csharp
List<Comment> omments = await client.CommentService.GetComments(1);
```

### Get notes by text
```csharp
List<Note> notes = await client.NoteService.GetByText("Text", 0, 10);
```
Other actions are executed similar to the above written example.
