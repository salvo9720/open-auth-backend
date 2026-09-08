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