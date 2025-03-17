-- +goose Up
-- +goose StatementBegin
CREATE TABLE document_reference_types
(
    id                TEXT        NOT NULL UNIQUE,
    reference_type_id INTEGER PRIMARY KEY,
    domain_id         TEXT,
    display_name      TEXT        NOT NULL,
    data              BYTEA       NOT NULL,
    created_by_id     TEXT        NOT NULL,
    updated_by_id     TEXT        NOT NULL,
    created_datetime  TIMESTAMPTZ NOT NULL,
    updated_datetime  TIMESTAMPTZ NOT NULL,
    is_deleted        BOOLEAN     NOT NULL DEFAULT FALSE,
    version           INTEGER     NOT NULL DEFAULT 1,
    concurrency_token TIMESTAMPTZ NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'utc')
);
-- +goose StatementEnd
-- +goose Down
-- +goose StatementBegin
SELECT 'down SQL query';
-- +goose StatementEnd
