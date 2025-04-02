-- +goose Up
-- +goose StatementBegin

CREATE TABLE approval_rules
(
    domain_id                TEXT      NOT NULL,
    entity_type_id           TEXT      NOT NULL,
    entity_type_updated_date TIMESTAMP NOT NULL,
    original_version         INTEGER   NOT NULL DEFAULT 0,
    version                  INTEGER   NOT NULL,
    is_active                BOOLEAN   NOT NULL,
    display_name             TEXT      NOT NULL,
    data                     BYTEA     NOT NULL,
    created_by               TEXT      NOT NULL,
    updated_by               TEXT      NOT NULL,
    created_at               TIMESTAMP NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'utc'),
    updated_at               TIMESTAMP NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'utc'),
    concurrency_token        TIMESTAMP NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'utc'),
    is_deleted               BOOL      NOT NULL DEFAULT FALSE,
    CONSTRAINT approval_rules_key UNIQUE (domain_id, entity_type_id, entity_type_updated_date, version)
);

CREATE UNIQUE INDEX idx_approval_rules_active ON approval_rules (domain_id, entity_type_id, entity_type_updated_date) WHERE is_active = true;
-- +goose StatementEnd

-- +goose Down
-- +goose StatementBegin
DROP TABLE approval_rules;
-- +goose StatementEnd
