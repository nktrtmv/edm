-- +goose Up
-- +goose StatementBegin

CREATE TABLE IF NOT EXISTS counters
(
    id
    TEXT
    NOT
    NULL,
    domain_id
    TEXT
    NOT
    NULL,
    entity_type_id
    TEXT,
    name
    TEXT
    NOT
    NULL,
    value
    INTEGER
    NOT
    NULL,
    PRIMARY
    KEY
(
    id
)
    );

-- +goose StatementEnd

-- +goose Down
