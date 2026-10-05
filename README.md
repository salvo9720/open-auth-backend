# open-auth-backend

1. Domain
2. Permission
3. User
4. UserDomain
5. Device
6. Session
7. AppDbContext
8. Migration
9. PostgreSQL
10. Login
11. Gestione sessione
12. Logout
13. Revoca sessioni altri dispositivi


--- db schema 

  ┌───────────────┐
                         │    DOMAINS    │
                         │───────────────│
                         │ id            │
                         │ name          │
                         └───────┬───────┘
                                 │
                                 │ N:N
                                 │
                         ┌───────▼────────┐
                         │  USER_DOMAINS  │
                         │─────────────────│
                         │ user_id        │
                         │ domain_id      │
                         │ permission_id  │
                         └───────┬────────┘
                                 │
                                 │
┌───────────────┐                │
│     USERS     │◄───────────────┘
│───────────────│
│ id            │
│ username      │
│ password_hash │
│ created_at    │
│ deleted_at    │
└───────┬───────┘
        │
        │ 1:N
        │
        ▼
┌───────────────┐
│    DEVICES    │
│───────────────│
│ id            │
│ user_id       │
│ name          │
│ created_at    │
│ deleted_at    │
└───────┬───────┘
        │
        │ 1:N
        │
        ▼
┌──────────────────┐
│     SESSIONS     │
│──────────────────│
│ id               │
│ user_id          │
│ device_id        │
│ token_hash       │
│ created_at       │
│ last_activity_at │
│ expires_at       │
│ revoked_at       │
└──────────────────┘

USER_DOMAINS
      │
      ▼
┌────────────────┐
│  PERMISSIONS   │
│────────────────│
│ id             │
│ level          │
└────────────────┘


--------------------------------------------------


user for default auth: admin admin.
presnet in method  protected void seedDatabase(ModelBuilder modelBuilder), 
for remove it, delete init data for database with method seedDatabase.




///////////////////////////////////////////////////////////////////////////////

pezzi da integrare
1) login FE
2) verifica del token 
3) uso del token da FE con la check su ricordami 
4) da integrare refresh token
5) recupero password da FE 
6) creare una funzione che validi il token e dica che siamo loggati, deve essere una funziona richiamabibile da altri bk
