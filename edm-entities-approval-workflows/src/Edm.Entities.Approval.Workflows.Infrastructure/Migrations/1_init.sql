-- +goose Up
-- +goose StatementBegin

CREATE TABLE approval_workflows
(
    id               TEXT      NOT NULL,
    entity_id        TEXT      NOT NULL,
    entity_domain_id TEXT      NOT NULL,
    status           TEXT      NOT NULL,
    data             BYTEA     NOT NULL,
    actualized_date  TIMESTAMP NULL
    created_date     TIMESTAMP NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'utc'),
    updated_date     TIMESTAMP NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'utc'),
    PRIMARY KEY (id)
);

-- +goose StatementEnd
-- +goose Down

-- +goose StatementBegin
-- +goose StatementEnd
