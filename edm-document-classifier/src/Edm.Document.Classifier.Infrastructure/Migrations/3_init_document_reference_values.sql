-- +goose Up
-- +goose StatementBegin
CREATE TABLE document_reference_values
(
    id                TEXT        NOT NULL,
    display_value     TEXT        NOT NULL,
    display_sub_value TEXT,
    reference_type_id INTEGER     NOT NULL,
    is_hidden         BOOLEAN     NOT NULL,
    created_by_id     TEXT        NOT NULL,
    updated_by_id     TEXT        NOT NULL,
    created_datetime  TIMESTAMPTZ NOT NULL,
    updated_datetime  TIMESTAMPTZ NOT NULL,
    concurrency_token TIMESTAMPTZ NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'utc')
);
-- +goose StatementEnd

-- +goose Down
-- +goose StatementBegin
SELECT 'down SQL query';
-- +goose StatementEnd
