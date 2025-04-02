-- +goose Up
-- +goose StatementBegin

CREATE TABLE signing_workflows
(
    id                TEXT      NOT NULL,
    entity_id         TEXT      NOT NULL,
    domain_id         TEXT      NOT NULL,
    status            TEXT      NOT NULL,
    status_changed_at TIMESTAMP NOT NULL,
    data              BYTEA     NOT NULL,
    concurrency_token TIMESTAMP NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'utc'),
    PRIMARY KEY (id)
);

-- +goose StatementEnd
-- +goose Down
-- +goose StatementBegin

DROP TABLE signing_workflows;

-- +goose StatementEnd
