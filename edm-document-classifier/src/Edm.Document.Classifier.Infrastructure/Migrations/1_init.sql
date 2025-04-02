-- +goose Up
-- +goose StatementBegin
CREATE TABLE document_classifiers
(
    document_template_id TEXT      NOT NULL,
    data                 BYTEA     NOT NULL,
    created_date         TIMESTAMP NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'utc'),
    updated_date         TIMESTAMP NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'utc'),
    data_for_search      JSON      NOT NULL,
    PRIMARY KEY (document_template_id)
);
-- +goose StatementEnd

-- +goose Down
-- +goose StatementBegin
-- +goose StatementEnd
