-- +goose Up
-- +goose StatementBegin
CREATE TABLE documents
(
    id                   TEXT      NOT NULL,
    template_id          TEXT      NOT NULL,
    template_system_name TEXT,
    status_id            TEXT      NOT NULL,
    data                 BYTEA     NOT NULL,
    created_by_id        TEXT      NOT NULL,
    updated_by_id        TEXT      NOT NULL,
    created_datetime     TIMESTAMP NOT NULL,
    updated_datetime     TIMESTAMP NOT NULL,
    concurrency_token    TIMESTAMP NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'utc'),
    PRIMARY KEY (id)
);
-- +goose StatementEnd

-- +goose Down
-- +goose StatementBegin
DROP TABLE documents;
-- +goose StatementEnd
