-- +goose Up
-- +goose StatementBegin

CREATE TABLE IF NOT EXISTS entity_token_counters
(
    counter_id   TEXT    NOT NULL,
    entity_token TEXT    NOT NULL,
    value        INTEGER NOT NULL,
    PRIMARY KEY (counter_id, entity_token)
);

-- +goose StatementEnd

-- +goose Down
