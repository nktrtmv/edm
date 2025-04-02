-- +goose Up
-- +goose StatementBegin
CREATE TABLE document_templates
(
    id                TEXT      NOT NULL,
    domain_id         TEXT      NOT NULL DEFAULT '8a3d776c-906a-4de2-9c20-1df638f1545b',
    system_name       TEXT,
    name              TEXT      NOT NULL,
    data              BYTEA     NOT NULL,
    created_by_id     TEXT      NOT NULL,
    updated_by_id     TEXT      NOT NULL,
    created_datetime  TIMESTAMP NOT NULL,
    updated_datetime  TIMESTAMP NOT NULL,
    is_deleted        BOOLEAN   NOT NULL DEFAULT FALSE,
    concurrency_token TIMESTAMP NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'utc'),
    PRIMARY KEY (id),
    CONSTRAINT system_name_and_domain_id_unique_constraint UNIQUE (system_name, domain_id)
);
-- +goose StatementEnd

-- +goose Down
-- +goose StatementBegin
DROP TABLE document_templates;
-- +goose StatementEnd
