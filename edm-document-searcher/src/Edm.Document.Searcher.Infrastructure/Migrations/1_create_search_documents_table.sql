-- +goose Up
-- +goose StatementBegin
CREATE TABLE search_documents
(
    id                TEXT      NOT NULL,
    template_Id       TEXT      NOT NULL,
    domain_id         TEXT      NOT NULL,
    attributes_values JSONB     NOT NULL,
    concurrency_token TIMESTAMP NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'utc'),
    PRIMARY KEY (id)
);
-- +goose StatementEnd

-- +goose Down
-- +goose StatementBegin
DROP TABLE search_documents;
-- +goose StatementEnd
